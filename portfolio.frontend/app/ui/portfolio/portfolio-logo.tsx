import Link from "next/link";

export default function PortfolioLogo() {
  return (
    <>
      <Link
        className={`font-extralight  text-orange-300 text-4xl`}
        href={"/home"}
      >
        <label>Lionel Janin</label>
      </Link>
    </>
  );
}
