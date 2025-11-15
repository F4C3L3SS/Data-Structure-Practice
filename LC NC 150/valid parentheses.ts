function isValid(s: string): boolean {
    const st = new Array();

    for (let i = 0; i < s.length; i++) {
        if (s[i] === "(" || s[i] === "{" || s[i] === "[") {
            st.push(s[i]);
        }

        if (s[i] === ")" || s[i] === "{" || s[i] === "]") {
            if (st.length === 0) return false;

            let top = st[st.length - 1];

            if ((s[i] === ")" && top !== "(") || (s[i] === "}" && top !== "{") || (s[i] === "]" && top !== "[")) {
                return false;
            }

            st.pop();
        }
    }

    return st.length === 0;
};

console.log(isValid("()[]{}"));