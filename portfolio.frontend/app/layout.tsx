import "@/app/ui/global.css";
import React from "react";
import { outfit } from "@/app/ui/fonts";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body
        className={`${outfit.className} bg-gray-900 antialiased text-gray-400`}
      >
        {children}
      </body>
    </html>
  );
}
