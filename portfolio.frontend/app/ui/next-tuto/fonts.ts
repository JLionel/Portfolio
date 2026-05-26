import { Inter, Lusitana, Outfit } from "next/font/google";

// Memo:
// 100: thin
// 200: extra light
// 300: light
// 400: regular
// 500: medium
// 600: semi bold
// 700: bold
// 800: extra bold
// 900: black


export const inter = Inter({ subsets: ["latin"] });

export const lusitana = Lusitana({
  weight: ["400", "700"],
  subsets: ["latin"],
});

export const outfit = Outfit({
  weight: ["400", "700"],
  subsets: ["latin"],
});
