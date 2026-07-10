import "@/app/ui/global.css";
import React from "react";
import { outfit } from "@/app/ui/fonts";
import { ThemeProvider } from "@/app/ui/theme/theme-provider";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en" suppressHydrationWarning>
      <body
        className={`${outfit.className} h-screen antialiased font-light text-neutral-900 bg-zinc-100 dark:bg-gray-900 dark:text-gray-400`}
      >
        <ThemeProvider attribute="class" defaultTheme="system" enableSystem>
          {children}
        </ThemeProvider>
      </body>
    </html>
  );
}
