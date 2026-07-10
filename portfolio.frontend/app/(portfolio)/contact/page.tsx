import { Metadata } from "next";
import Link from "next/link";

export const metadata: Metadata = {
  title: "Contact",
};

export default function Page() {
  return (
    <>
      <div className={"main-page"}>
        <p>Contact page WIP</p>
        <Link
          className={"text-blue-500 underline underline-offset-2"}
          href={"mailto:li.janin@laposte.net"}
        >
          li.janin@laposte.net
        </Link>
      </div>
    </>
  );
}
