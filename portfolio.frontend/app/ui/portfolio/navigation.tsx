import Link from "next/link";

const navLinks = [
  { name: "Home", href: "/home" },
  { name: "Projects", href: "/projects" },
  { name: "Resume", href: "/resume" },
  { name: "Contact", href: "/contact" },
];

export default function Navigation() {
  return (
    <div className={"flex flex-row gap-10 "}>
      {navLinks.map((link) => {
        return (
          <Link key={`${link.name}`} href={link.href}>
            <div className="text-2xl">{link.name}</div>
          </Link>
        );
      })}
    </div>
  );
}
