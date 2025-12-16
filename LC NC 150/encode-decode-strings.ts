function encodeDecode() {
    const strs = ["neet","code","love","you"];

    let op = [];

    op.push(strs.join("-"));

    console.log(op);

    let op2 = [];

    op2 = op[0].split("-");
    console.log(op2);
}

encodeDecode();