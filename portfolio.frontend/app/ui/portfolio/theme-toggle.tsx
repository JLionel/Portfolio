"use client";

import { useState } from "react";

export default function ThemeToggle() {
  const [isChecked, setIsChecked] = useState(false);

  const handleToggle = (value: boolean) => {
    console.log(value);
    setIsChecked(value);
  };

  return (
    <label className="w-auto inline-flex items-center cursor-pointer">
      <input
        type="checkbox"
        value=""
        className="sr-only peer"
        onChange={(value) => handleToggle(value.target.checked)}
      />
      <div
        className={`relative w-17 h-9 bg-neutral-800 peer-focus:outline-none rounded-full peer-checked:bg-orange-300`}
      />
      <span
        className={`absolute m-1 grid content-center justify-center bg-white rounded-full h-7 w-7 transition peer-checked:translate-x-8`}
      >
        {isChecked ? (
          <div className={"bi bi-brightness-high text-black"} />
        ) : (
          <div className={"bi bi-moon text-black "} />
        )}
      </span>
    </label>
  );
}
