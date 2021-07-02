"use strict";

// alert('click ok to begin');

// hoisting (with var) allows you to initialize a variable BEFORE declaring it.
let name1 = 'mark';
// var name;
console.log(name1);

let age = 25;
console.log(`My name is ${name1} adn I'm ${age} years old.`)

age = 'twenty-five';

console.log(`My name is ${name1} adn I'm ${age} years old.`)

let me = 'mark', my = 'house', age1 = 24;
console.log(`My name is ${me} and I'm ${age1} years old. I live in my ${my}`)

const shoe = 'adidas';
//shoe = 'myadidas';

let mybool = 2 < 1;
//mybool = false;
console.log(mybool);

let myBool1;

console.log(myBool1);
age = 25;
console.log(` shoe is a ${typeof shoe}`);
console.log(` myBool is a ${typeof (mybool)}`);
console.log(` age is a ${typeof age}`);

// let ageNum = 25;
// let ageString = '25';
// let doubleEqual = ageNum == ageString;// '==' will try changing the types of hte operands to see if thre is any way they can be equal.

let ageNum = 25;
let ageString = '25';
let doubleEqual = ageNum === ageString;// '===' does NOT change types ot see if they could be equal

console.log(doubleEqual);



let a = {};
let c = {};
let b = a;
let d = '13';
let e = 13;
console.log(a == b);
console.log(a === b);
console.log(a == c);
console.log(a === c);
console.log(d == e);
console.log(d === e);

let emptyOj = {};
if ({}) {
    console.log('it\'s truthy');
}
else {
    console.log('it\'s falseys');
}

// you can convert anything to a string.. 
// BUT convertions ate JIT changed and don't change the original
let name2 = 24;
console.log(typeof (String(name2)));
console.log(typeof name2);

//to change the original, you have to set it = to a string
name2 = 'now Im a string';
console.log(typeof name2);

let age2 = 'v';

console.log(Boolean(age2));

console.log(Math.ceil(Math.random() * 10));

console.log(Math.min(2, 6, 87, 90, 100, 2, .5, 20000));

let myMap = new Map();
myMap.set(1, 'one');
myMap.set(2, 'two');
myMap.set(3, 'three');
myMap.set(4, 'four');
myMap.set(2, 'twenty-two');


myMap.forEach((x, y) => console.log(`the key is ${y} and the value is ${x}`));

// function(obj value, obj key, Map wholMap){
//     return console.log(value);
// }
