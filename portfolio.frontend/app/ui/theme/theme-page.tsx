"use client";

import dynamic from "next/dynamic";

const ThemeToggle = dynamic(() => import("@/app/ui/theme/theme-toggle"), {
  ssr: false,
});

export default function ThemePage({ className }: { className?: string }) {
  return <ThemeToggle className={className} />;
}
