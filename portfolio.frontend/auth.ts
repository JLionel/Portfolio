import NextAuth from "next-auth";
import { authConfig } from "./auth.config";
import Credentials from "next-auth/providers/credentials";
import { z } from "zod";

import type { User } from "@/app/lib/definitions";

async function getUser(
  email: string,
  password: string,
): Promise<User | undefined> {
  try {
    const fetchResponse = await fetch(
      `${process.env.API_NEXT_TUTO_DATA_URL}/Users/auth?email=${email}&password=${password}`,
    );

    if (fetchResponse.status === 401) return undefined;
    if (fetchResponse.status === 404) return undefined;

    console.log(`fetch response : ${fetchResponse.status}`);

    const user: User = await fetchResponse.json();

    console.log(user);

    return user;
  } catch (error) {
    console.error("Failed to fetch user:", error);
    throw new Error("Failed to fetch user.");
  }
}

export const { handlers, signIn, signOut, auth } = NextAuth({
  ...authConfig,
  providers: [
    Credentials({
      async authorize(credentials) {
        const parsedCredentials = z
          .object({ email: z.email(), password: z.string().min(6) })
          .safeParse(credentials);

        if (parsedCredentials.success) {
          const { email, password } = parsedCredentials.data;
          const user = await getUser(email, password);

          if (!user) return null;

          return user;
        }
        return null;
      },
    }),
  ],
});
