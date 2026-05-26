import { cormorant_sc } from "@/app/ui/fonts";
import Link from "next/link";

export default function PortfolioLogo() {
  return (
    <>
      <Link
        className={`${cormorant_sc.className} text-4xl text-shadow-[3px_3px_2px_#000000]`}
        href={"/home"}
      >
        <label>Lionel Janin</label>
      </Link>
    </>
  );
}
