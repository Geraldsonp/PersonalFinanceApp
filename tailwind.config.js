/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./Pages/**/*.{razor,html,cshtml,css}", "./Layout/*.{razor,html,cshtml,css}","./Components/*.{razor,html,cshtml,css}", "./node_modules/flowbite/**/*.js"],
    theme: {
        extend: {
            colors: {
                beige: {
                    100: '#F8F4F0',
                    500: '#98908B',
                },
                slate: {
                    600: '#666CA3',
                },
                grey: {
                    100: '#F2F2F2',
                    300: '#B3B3B3',
                    500: '#696868',
                    900: '#201F24',
                },
                green: '#277C78',
                yellow: '#F2CDAC',
                cyan: '#82C9D7',
                navy: '#626070',
                red: '#C94736',
                purple: '#826CB0',
                turquoise: '#597C7C',
                brown: '#93674F',
                magenta: '#934F6F',
                blue: '#3F82B2',
                'navy-grey': '#97A0AC',
                'army-green': '#7F9161',
                gold: '#CAB361',
                orange: '#BE6C49',
            },
            fontFamily: {
                'public-sans': ['Public Sans', 'sans-serif'],
            },
            fontSize: {
                '32': '32px',
                '20': '20px',
                '16': '16px',
                '14': '14px',
                '12': '12px',
            },
            lineHeight: {
                '120': '120%',
                '150': '150%',
            },
            letterSpacing: {
                'normal': '0px',
            },
            spacing: {
                '500': '40px',
                '400': '32px',
                '300': '24px',
                '250': '20px',
                '200': '16px',
                '150': '12px',
                '100': '8px',
                '50': '4px',
            },
            gridTemplateColumns: {
                // Simple 16 column grid
                '16': 'repeat(16, minmax(0, 1fr))',
            }
        },
    },
    plugins: [require('flowbite/plugin')],
}

