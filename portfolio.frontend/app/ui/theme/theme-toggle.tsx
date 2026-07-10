"use client";

import { Moon, Sun } from "lucide-react";
import { useTheme } from "next-themes";
import { localThemes } from "@/app/ui/theme/theme-provider";
import clsx from "clsx";

export default function ThemeToggle({ className }: { className?: string }) {
  const { theme, resolvedTheme, setTheme } = useTheme();

  const handleToggle = (value: boolean) => {
    setTheme(value ? localThemes.light : localThemes.dark);
  };

  // to display the correct theme colors/icons for the toggle the first time we open the page
  const themeLight =
    (theme === localThemes.system ? resolvedTheme : theme) ===
    localThemes.light;

  return (
    <label
      className={clsx(
        "w-full inline-flex items-center cursor-pointer",
        className,
      )}
    >
      <input
        type="checkbox"
        value=""
        className="sr-only peer"
        onChange={(value) => handleToggle(value.target.checked)}
        checked={themeLight}
      />
      <div
        className={`relative w-full h-8 bg-orange-300 peer-focus:outline-none rounded-full dark:bg-neutral-800`}
      />
      <span
        className={`absolute m-1 grid place-items-center text-neutral-900 bg-white rounded-full h-6 w-6 transition peer-checked:translate-x-11`}
      >
        {themeLight ? (
          <Sun className={"size-80/100"} />
        ) : (
          <Moon className={"size-80/100"} />
        )}
      </span>
    </label>
  );
}
