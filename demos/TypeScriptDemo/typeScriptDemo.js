import { Zombie } from './PersonInterface.js';
//import { Zombie } from './PersonInterface'; this version is how Angular will put it.


let mark;
mark = 'markString';
console.log(mark);
let num = 0;
num += 5;
console.log(num);
let name1 = 'errors';
console.log(name1);
// name1 = 2;
let myReturn = function myFunc(name2) {
    console.log(name2);
    return name2;
};
console.log(myReturn('I\'m an error'));
let myPerson = { name: 'mark', num1: 42 };
console.log(`${myPerson.name} is ${myPerson.num1}.`);
let myZombie = new Zombie('Carl');
console.log(`the zombie is ${myZombie.birthName} and he's killed ${Zombie.victims} people`);
Zombie.victims += 5;
console.log(`the zombie is ${myZombie.birthName} and he's killed ${Zombie.victims} people`);
