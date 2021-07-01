console.log('hello, world');
let doc = document.getElementsByClassName("class1");
let ids = document.getElementById("myId");

// fetch('http://api.icndb.com/jokes/random/3')
//     // .then(res => {
//     //     console.log('I\'m in the first .then() statement');
//     //     return res.json();
//     // })
//     .then(r => r.json())
//     .then(res => {
//         console.log(res);
//         console.log('I\'m in the second .then() statement');
//     });

//the lambda above is the equivalent of...
// var func = function (res) {
//     return res.json();
// }

let variable1 = [];

// now lets get something from our API
fetch('https://localhost:44335/api/RpsGame/PlayerList')
    .then(res => {
        if (res.status == 200) {
            let text = res.type;
            console.log(`The response is ${res.status}\nthe status text is ${text}\nthe response url is ${res.url}\n the response.ok is ${res.ok} `);
            return res.json();
        }
        else {
            console.log('the response indicates a failure to communicate')
        }
    })
    .then(res => {
        // use a for loop to push each result indivudually onto this array.
        res.forEach(x => {
            console.log(x.fname);
            variable1.push(x);
            return res;
        });
    })
    .then(res => {
        variable1.forEach(x => console.log(`${x.fname} ${x.lname} ${x.street} ${x.state}`))
    })
    .finally(() => {
        console.log('this is the finally block and it always runs.')
    })
    .catch(err => console.log('1. there was an error'));

//print out the objects again.
variable1.forEach(x => console.log(`${x.fname} ${x.lname} ${x.street} ${x.state}`))


//POST in fetch
var player = {
    fname: "Skeeet",
    lname: "Ulric",
    myCountry: "nowhere",
    street: "456 morethanthree",
    state: "mississippi",
    city: "blownup",
    myAge: 50
}
fetch('https://localhost:44335/api/RpsGame/CreateNewPlayer',
    {
        method: 'POST',
        headers: {
            'content-Type': 'application/json'
        },
        body: JSON.stringify(player)
    })
    .then(res => res.json())
    .then(res => {
        console.log(`the returned player is ${res.fname}`)
        for (item of doc) {
            item.innerText = `the returned player is ${res.fname}`
        }
    });