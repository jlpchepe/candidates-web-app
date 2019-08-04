module.exports = {
    env: {
        browser: true
    },
    parser: "@typescript-eslint/parser",
    parserOptions: {
        ecmaVersion: 2018, // Allows for the parsing of modern ECMAScript features
        sourceType: "module", // Allows for the use of imports
        ecmaFeatures: {
            jsx: true // Allows for the parsing of JSX
        },
        project: "./tsconfig.json"
    },
    plugins: [
        "@typescript-eslint"
    ],
    rules: {
        // Indent with 4 spaces
        "@typescript-eslint/indent": [
           "error",
            4,
            { "SwitchCase": 1 }
        ],
        // Always end statements with semicolor ";"
        semi: [ "error", "always" ],
        // Always use double quotes
        quotes: [ "error", "double" ]
    }
}