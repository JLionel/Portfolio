import { Metadata } from "next";
import { permanentRedirect } from "next/navigation";

export const metadata: Metadata = {
  title: "Acme",
};

export default function Page() {
  permanentRedirect("/home");
}
