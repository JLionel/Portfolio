import { Metadata } from "next";
import PortfolioLogo from "@/app/ui/portfolio/portfolio-logo";
import Navigation from "@/app/ui/portfolio/navigation";
import ThemeToggle from "@/app/ui/portfolio/theme-toggle";

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
          "h-36 flex flex-row bg-neutral-50 shadow-[0_15px_19px_#E4E4E7] dark:bg-neutral-900 dark:shadow-[0_15px_19px_#000000]"
        }
      >
        <div className={"w-1/3 p-6"}>
          <PortfolioLogo />
        </div>
        <div className={"w-1/3 place-items-center content-center"}>
          <Navigation />
        </div>
        <div
          className={"w-1/3 content-center place-items-end pr-6 grid gap-y-3"}
        >
          <ThemeToggle />
          <div className={"grid gap-y-0.5"}>
            <a
              href={"https://github.com/JLionel"}
              target={"_blank"}
              className={"bi bi-github text-orange-300 text-2xl"}
            ></a>
            <a
              href={"https://www.linkedin.com/in/lioneljanin/"}
              target={"_blank"}
              className={"bi bi-linkedin text-orange-300 text-2xl"}
            ></a>
          </div>
        </div>
      </div>
      {children}
    </>
  );
}
