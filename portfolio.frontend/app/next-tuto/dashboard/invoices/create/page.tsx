import Form from "@/app/ui/next-tuto/invoices/create-form";
import Breadcrumbs from "@/app/ui/next-tuto/invoices/breadcrumbs";
import { fetchCustomers } from "@/app/lib/data";
import { Metadata } from "next";

export const metadata: Metadata = {
  title: "Create Invoice",
};

export default async function Page() {
  const customers = await fetchCustomers();

  return (
    <main>
      <Breadcrumbs
        breadcrumbs={[
          { label: "Invoices", href: "/next-tuto/dashboard/invoices" },
          {
            label: "Create Invoice",
            href: "/next-tuto/dashboard/invoices/create",
            active: true,
          },
        ]}
      />
      <Form customers={customers} />
    </main>
  );
}
