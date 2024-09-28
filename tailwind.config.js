/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Pages/*.{razor,html,cshtml}","./node_modules/flowbite/**/*.js"],
  theme: {
    extend: {},
  },
  plugins: [ require('flowbite/plugin')],
}

