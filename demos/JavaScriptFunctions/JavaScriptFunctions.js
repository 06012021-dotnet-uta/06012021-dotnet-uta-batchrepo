function funcName(name, age = 23) {
    console.log(`The name is ${name} and the age is ${age}`);
    return;
    let age1 = 23;// you cna't do anthing after a return keyword. 
    // JS returns and doens't do anything else after return.

}

funcName('MARK');// when fewer args are sent than there are prams, 
// the remaining params are undefined (if they have no defualt value)
funcName(23);

function funcInfunc(name, age) {
    console.log(age);
    //create a function inside a function
    function funcInFuncInFunc() {
        console.log(`my name is ${name}`);
    }
    //call the internal function
    funcInFuncInFunc();
    return ++age;//return the age that was sent in.
}

let age2 = funcInfunc('myName', 100);
console.log(age2);

//function Expressions are functions assigned to a variable
let myfunc = function (name, age) {
    console.log(age);
    return ++age;//return the age that was sent in.
}

let myAge1 = myfunc('mark', 199);
console.log(myAge1);

let myFunc1 = () => 110;
let return1 = myFunc1();
console.log(return1);

let myFunc2 = (x, y) => {
    console.log(x);
    return y * y;
}

let return2 = myFunc2(2, 3);
console.log(return2);

// 1. create a function that takes a callback func as a parameter
let callBackfunc = (x, callBack) => {
    return callBack(x);
}


// 2. create a functioin to send as a callback function
function origCallback(param) {
    return ++param;
}

// 3. call the first function with the callback function as an arg.
let return3 = callBackfunc(99, origCallback);
console.log(`the callback function returned =>${return3}`);

// IIFE (say 'iffie') - Immediately invoked FunctionExpression is created and called as soon as the 
// runtime gets to it. 
(function () {
    console.log(Math.pow(2, 3));
})();

// you can declare a variable inside the IIFE
(function () {
    let myvar = 4;
    console.log(Math.pow(2, myvar));
})();


// function ClosureFunc(myNum) {
//     let myOtherNum = 0;
//     return function () {
//         //++myOtherNum;
//         return myNum + myOtherNum++;
//     };
// };

// let return4 = ClosureFunc(1);
// let return5 = return4();
// console.log(`ClosureFunc returned ${return5}`);
// return4 = ClosureFunc(1);
// console.log(`ClosureFunc returned ${return4()}`);

function Cf1() {
    let count = 0;
    return function () {
        return count++;
    }
}

let return6 = Cf1();
let return7 = return6();
console.log(return7);

return7 = return6();
console.log(return7);

return7 = return6();
console.log(return7);

return7 = return6();
console.log(return7);

function ma(x) {
    return function (y) {
        // if the value sent in is above 
        // 100 they add then original arg with the second.
        if (y > 100) {
            return x + y;
        }
        else {
            return x
        }
    }
};

let add5 = ma(5);
console.log(add5(4));
console.log(add5(101));



