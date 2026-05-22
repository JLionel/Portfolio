"use server";

import { z } from "zod";
import { revalidatePath } from "next/cache";
import { redirect } from "next/navigation";
import { signIn } from "@/auth";
import { AuthError } from "next-auth";
import { connection } from "next/server";

const FormSchema = z.object({
  id: z.string(),
  customerId: z.string({ error: "Please select a customer." }),
  amount: z.coerce
    .number()
    .gt(0, { error: "Please enter an amount greater than $0." }),
  status: z.enum(["pending", "paid"], "Please select an invoice status."),
  date: z.string(),
});

const ZodInvoice = FormSchema.omit({ id: true, date: true });

export type State = {
  properties?: {
    customerId?: {
      errors: string[];
    };
    amount?: {
      errors: string[];
    };
    status?: {
      errors: string[];
    };
  };
  message?: string | null;
};

export async function createInvoice(prevState: State, formData: FormData) {
  const validatedFields = ZodInvoice.safeParse({
    customerId: formData.get("customerId"),
    amount: formData.get("amount"),
    status: formData.get("status"),
  });

  // If form validation fails, return errors early. Otherwise, continue.
  if (!validatedFields.success) {
    return {
      properties: z.treeifyError(validatedFields.error).properties,
      message: "Missing Fields. Failed to Create Invoice.",
    };
  }
  const { customerId, amount, status } = validatedFields.data;
  const amountInCents = amount * 100;

  await connection();
  try {
    await fetch(`${process.env.API_NEXT_TUTO_DATA_URL}/Invoices`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        customerId,
        amount: amountInCents,
        status,
      }),
    });
  } catch (error) {
    console.error(error);
    return {
      message: "Database Error: Failed to Create Invoice.",
    };
  }

  revalidatePath("/dashboard/invoices");
  redirect("/dashboard/invoices");
}

export async function updateInvoice(
  id: string,
  prevState: State,
  formData: FormData,
) {
  const validatedFields = ZodInvoice.safeParse({
    customerId: formData.get("customerId"),
    amount: formData.get("amount"),
    status: formData.get("status"),
  });

  // If form validation fails, return errors early. Otherwise, continue.
  if (!validatedFields.success) {
    return {
      properties: z.treeifyError(validatedFields.error).properties,
      message: "Missing Fields. Failed to Create Invoice.",
    };
  }

  const { customerId, amount, status } = validatedFields.data;
  const amountInCents = amount * 100;

  await connection();
  try {
    await fetch(`${process.env.API_NEXT_TUTO_DATA_URL}/Invoices?id=${id}`, {
      method: "PATCH",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        status,
        amount: amountInCents,
        customerId,
      }),
    });
  } catch (error) {
    console.error(error);
    return {
      message: "Database Error: Failed to Update Invoice.",
    };
  }

  revalidatePath("/dashboard/invoices");
  redirect("/dashboard/invoices");
}

export async function deleteInvoiceWithId(id: string) {
  await connection();
  try {
    await fetch(`${process.env.API_NEXT_TUTO_DATA_URL}/Invoices/${id}`, {
      method: "DELETE",
    });
  } catch (error) {
    console.error(error);
  }

  revalidatePath("/dashboard/invoices");
}

export async function authenticate(
  prevState: string | undefined,
  formData: FormData,
) {
  try {
    await signIn("credentials", formData);
  } catch (error) {
    if (error instanceof AuthError) {
      switch (error.type) {
        case "CredentialsSignin":
          return "Invalid credentials.";
        default:
          return "Something went wrong.";
      }
    }
    throw error;
  }
}
