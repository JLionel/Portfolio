import { Metadata } from "next";
import Link from "next/link";

export const metadata: Metadata = {
  title: "Projects",
};

export default function Page() {
  return (
    <>
      <div className={"main-page"}>
        <p>Projects page WIP</p>
        <p className={"text-blue-500 underline underline-offset-2"}>
          <Link href={"https://github.com/JLionel"}>Github</Link>
        </p>
      </div>
    </>
  );
}
