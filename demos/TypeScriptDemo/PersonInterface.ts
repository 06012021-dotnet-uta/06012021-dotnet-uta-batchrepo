interface Person {
    name: string;
    num1: number;
}

class Zombie {
    static victims: number = 0;
    constructor(public birthName: string) {
    }
}

export { Person, Zombie };