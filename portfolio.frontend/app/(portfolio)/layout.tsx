import { Metadata } from "next";

export const metadata: Metadata = {
  title: {
    template: "%s | Lionel Janin",
    default: "Lionel Janin",
  },
  description: "Lionel Janin Portfolio",
};

export default function Layout({ children }: { children: React.ReactNode }) {
  return (
    <div>
      <p>shared layout here</p>
      {children}
    </div>
  );
}
