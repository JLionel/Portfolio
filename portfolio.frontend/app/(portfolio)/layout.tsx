import { Metadata } from "next";
import PortfolioLogo from "@/app/ui/portfolio/portfolio-logo";
import Navigation from "@/app/ui/portfolio/navigation";

export const metadata: Metadata = {
  title: {
    template: "%s | Lionel Janin",
    default: "Lionel Janin",
  },
  description: "Lionel Janin Portfolio",
};

export default function Layout({ children }: { children: React.ReactNode }) {
  return (
    <>
      <div
        className={
          "h-[150] bg-neutral-900 flex flex-row shadow-[0_15px_19px_#000000]"
        }
      >
        <div className={"w-1/3 p-6"}>
          <PortfolioLogo />
        </div>
        <div className={"w-1/3 place-items-center content-center"}>
          <Navigation />
        </div>
        <div className={"hidden w-1/3 content-center justify-end"}>
          <p>Links</p>
        </div>
      </div>
      {children}
    </>
  );
}
