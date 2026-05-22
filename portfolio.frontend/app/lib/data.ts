import {
  Card,
  CustomerField,
  CustomersTableType,
  InvoicesTable,
  LatestInvoiceRaw,
  Revenue,
} from "./definitions";
import { formatCurrency } from "./utils";
import { connection } from "next/server";

export async function fetchRevenue() {
  await connection();
  try {
    // Artificially delay a response for demo purposes.
    // Don't do this in production :)

    console.log("Fetching revenue data...");
    await new Promise((resolve) => setTimeout(resolve, 3000));

    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Revenue`,
      {
        cache: "no-cache",
      },
    );
    const data: Revenue[] = await fetchResponse.json();

    console.log("Data fetch completed after 3 seconds.");

    return data;
  } catch (error) {
    console.error("Database Error:", error);
    throw new Error("Failed to fetch revenue data.");
  }
}

export async function fetchLatestInvoices() {
  await connection();
  try {
    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Invoices/Latest`,
      {
        cache: "no-cache",
      },
    );
    const data: LatestInvoiceRaw[] = await fetchResponse.json();

    const latestInvoices = data.map((invoice) => ({
      ...invoice,
      amount: formatCurrency(invoice.amount),
    }));

    return latestInvoices;
  } catch (error) {
    console.error("Database Error:", error);
    throw new Error("Failed to fetch the latest invoices.");
  }
}

export async function fetchCardData() {
  await connection();
  try {
    // You can probably combine these into a single SQL query
    // However, we are intentionally splitting them to demonstrate
    // how to initialize multiple queries in parallel with JS.

    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Card`,
      {
        cache: "no-cache",
      },
    );
    const data: Card = await fetchResponse.json();

    const numberOfInvoices = Number(data.countInvoices ?? "0");
    const numberOfCustomers = Number(data.countCustomers ?? "0");
    const totalPaidInvoices = formatCurrency(data.paid ?? "0");
    const totalPendingInvoices = formatCurrency(data.pending ?? "0");

    return {
      numberOfCustomers,
      numberOfInvoices,
      totalPaidInvoices,
      totalPendingInvoices,
    };
  } catch (error) {
    console.error("Database Error:", error);
    throw new Error("Failed to fetch card data.");
  }
}

const ITEMS_PER_PAGE = 6;
export async function fetchFilteredInvoices(
  query: string,
  currentPage: number,
) {
  const offset = (currentPage - 1) * ITEMS_PER_PAGE;

  await connection();
  try {
    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Invoices/Filtered?query=${query}&limit=${ITEMS_PER_PAGE}&offset=${offset}`,
      {
        cache: "no-cache",
      },
    );
    const invoices: InvoicesTable[] = await fetchResponse.json();

    return invoices;
  } catch (error) {
    console.error("Database Error:", error);
    throw new Error("Failed to fetch invoices.");
  }
}

export async function fetchInvoicesPages(query: string) {
  await connection();
  try {
    const data = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Invoices/Pages?query=${query}`,
      {
        cache: "no-cache",
      },
    ).then((res) => res.json());

    return Math.ceil(Number(data) / ITEMS_PER_PAGE);
  } catch (error) {
    console.error("Database Error:", error);
    throw new Error("Failed to fetch total number of invoices.");
  }
}

export async function fetchInvoiceById(id: string) {
  await connection();
  try {
    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Invoices/${id}`,
      {
        cache: "no-cache",
      },
    );
    console.log(fetchResponse.status);

    // better way to handle 404 in next with an ASP.NET api?
    if (fetchResponse.status === 404) return null;

    const invoice = await fetchResponse.json();

    invoice.amount = invoice.amount / 100;

    return invoice;
  } catch (error) {
    console.error("Database Error:", error);
    throw new Error("Failed to fetch invoice.");
  }
}

export async function fetchCustomers() {
  await connection();
  try {
    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Customers`,
      {
        cache: "no-cache",
      },
    );
    const customer: CustomerField[] = await fetchResponse.json();

    return customer;
  } catch (err) {
    console.error("Database Error:", err);
    throw new Error("Failed to fetch all customers.");
  }
}

export async function fetchFilteredCustomers(query: string) {
  await connection();
  try {
    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Customers/Filtered?query=${query}`,
      {
        cache: "no-cache",
      },
    );
    const data: CustomersTableType[] = await fetchResponse.json();

    const customers = data.map((customer) => ({
      ...customer,
      totalPending: formatCurrency(customer.totalPending),
      totalPaid: formatCurrency(customer.totalPaid),
    }));

    return customers;
  } catch (err) {
    console.error("Database Error:", err);
    throw new Error("Failed to fetch customer table.");
  }
}
