let myObj = {};

myObj.name = 'Mark';
myObj.age = 42;
console.log(`Myname and age are ${myObj.name} ${myObj.age}`)
myObj.name = 43;
console.log(`Myname and age are ${myObj.name} ${myObj.age}`)

function myObj1(a, n) {
    return {
        age: a,
        name: n
    };
}

let myObj2 = myObj1(100, 'billy');
console.log(`Myname and age are ${myObj2.name} ${myObj2.age}`)

// thisis the same as the function ABOVE buy IS NOT REUSEABLE
let myObj3 = {
    age: 10,
    name: 'billys Brother'
};

myObj.newobj = myObj3;
console.log(`My new obj prop ${myObj.newobj.name} ${myObj.newobj.age}`)

//assign a function to the object
myObj.newFunc = () => console.log('I\'m the arrow function');

// invoke the objects function
myObj.newFunc();

// see if a certain property exists on the object
let exists = 'names' in myObj
console.log(exists);

class Person {
    constructor(name) {
        this.name = name;
    }

    JustName() {
        return `My Name is ${this.name}`;
    }
}


class Player extends Person {
    constructor(name, age, Canada) {
        super(name);// you must call the super(base) class constructor before assigning any of the values to properties.
        //this.fname = name;
        this.age = age;
        this.myHomeland = Canada;
    }

    Allinfo() {
        return `Hello, My name is ${this.fname}. I live in ${this.myHomeland} and I\'m ${this.age} years old.`;
    }
}

let markObj = new Player('Mark, eh', 42, 'Canada');

console.log(markObj.Allinfo());// call this classes method
console.log(markObj.JustName());// call the supers classes method

