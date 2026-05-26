import { Metadata } from "next";
import Link from "next/link";

export const metadata: Metadata = {
  title: "Contact",
};

export default function Page() {
  return (
    <main>
      <p>Contact page WIP</p>
      <Link href={"mailto:li.janin@laposte.net"}>li.janin@laposte.net</Link>
    </main>
  );
}
