/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Pages/*.{razor,html,cshtml}","./Layout/*.{razor,html,cshtml}","./node_modules/flowbite/**/*.js"],
  theme: {
    extend: {
      gridTemplateColumns: {
        // Simple 16 column grid
        '16': 'repeat(16, minmax(0, 1fr))',
      }
    },
  },
  plugins: [ require('flowbite/plugin')],
}

