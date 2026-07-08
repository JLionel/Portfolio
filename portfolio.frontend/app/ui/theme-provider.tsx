"use client";

import * as React from "react";
import { ThemeProvider as NextThemesProvider } from "next-themes";

export const localThemes = { light: "light", dark: "dark", system: "system" };

export function ThemeProvider({
  children,
  ...props
}: React.ComponentProps<typeof NextThemesProvider>) {
  return (
    <NextThemesProvider
      themes={[localThemes.light, localThemes.dark]}
      {...props}
    >
      {children}
    </NextThemesProvider>
  );
}
