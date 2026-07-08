"use client";

import { Moon, Sun } from "lucide-react";
import { useEffect, useState } from "react";
import { useTheme } from "next-themes";
import { localThemes } from "@/app/ui/theme-provider";

export default function ThemeToggle() {
  const [mounted, setMounted] = useState(false);
  const [isChecked, setIsChecked] = useState(false);
  const { theme, resolvedTheme, setTheme } = useTheme();

  const handleToggle = (value: boolean) => {
    setIsChecked(value);
    setTheme(value ? localThemes.light : localThemes.dark);
  };

  useEffect(() => {
    setMounted(true);

    let finalTheme = theme;

    if (theme === localThemes.system) finalTheme = resolvedTheme;

    console.log(finalTheme);

    setIsChecked(finalTheme === localThemes.light);
  }, [theme, resolvedTheme, localThemes]);

  if (!mounted) {
    return null;
  }

  return (
    <label className="w-auto inline-flex items-center cursor-pointer">
      <input
        type="checkbox"
        value=""
        className="sr-only peer"
        onChange={(value) => handleToggle(value.target.checked)}
        checked={isChecked}
      />
      <div
        className={`relative w-17 h-9 bg-orange-300 peer-focus:outline-none rounded-full dark:bg-neutral-800`}
      />
      <span
        className={`absolute m-1 grid content-center justify-center text-neutral-900 bg-white rounded-full h-7 w-7 transition peer-checked:translate-x-8`}
      >
        {isChecked ? <Sun /> : <Moon />}
      </span>
    </label>
  );
}
