import { Metadata } from "next";
import PortfolioLogo from "@/app/ui/portfolio/portfolio-logo";
import Navigation from "@/app/ui/portfolio/navigation";
import ThemePage from "@/app/ui/theme/theme-page";
import React from "react";

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
      <header
        className={
          "h-24 flex flex-row bg-neutral-50 shadow-[0_15px_19px_#E4E4E740] dark:bg-neutral-900 dark:shadow-[0_15px_19px_#00000040]  [grid-area:nav]"
        }
      >
        <div className={"w-1/3 p-3"}>
          <PortfolioLogo />
        </div>
        <div className={"w-1/3 place-items-center content-center"}>
          <Navigation />
        </div>
        <div className={"w-1/3 content-center place-items-end pr-3"}>
          <div className={"w-19"}>
            <ThemePage className={"col-span-2"} />
          </div>
        </div>
      </header>
      <div
        className={"w-full bg-zinc-200 dark:bg-neutral-700 [grid-area:line]"}
      ></div>
      <main className={"h-full overflow-hidden [grid-area:main]"}>
        <div
          className={
            "h-full bg-zinc-200 dark:bg-neutral-700 [grid-area:line-L]"
          }
        ></div>
        {children}
        <div
          className={
            "h-full bg-zinc-200 dark:bg-neutral-700 [grid-area:line-R]"
          }
        ></div>
      </main>
    </>
  );
}
