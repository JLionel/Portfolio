import Form from "@/app/ui/next-tuto/invoices/edit-form";
import Breadcrumbs from "@/app/ui/next-tuto/invoices/breadcrumbs";
import { fetchCustomers, fetchInvoiceById } from "@/app/lib/data";
import { Metadata } from "next";
import { notFound } from "next/navigation";

export const metadata: Metadata = {
  title: "Edit Invoice",
};

export default async function Page(props: { params: Promise<{ id: string }> }) {
  const params = await props.params;

  const id = params.id;

  const [invoice, customers] = await Promise.all([
    fetchInvoiceById(id),
    fetchCustomers(),
  ]);

  if (!invoice) {
    notFound();
  }

  return (
    <main>
      <Breadcrumbs
        breadcrumbs={[
          { label: "Invoices", href: "/next-tuto/dashboard/invoices" },
          {
            label: "Edit Invoice",
            href: `/next-tuto/dashboard/invoices/${id}/edit`,
            active: true,
          },
        ]}
      />
      <Form invoice={invoice} customers={customers} />
    </main>
  );
}
