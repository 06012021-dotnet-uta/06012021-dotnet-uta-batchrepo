console.log('hello, world');

function DoIt() {
    console.log('Hey, Mark. You are tooo lazy.');
    console.log(`the readyState is => ${this.readyState}`);
}


// instantiate the object that will make and receive the request
var request = new XMLHttpRequest();

// tell the request object what to do when the response is received.
//request.onreadystatechange = DoIt;
request.onreadystatechange = () => {
    console.log(`the readyState is => ${request.readyState}`);
    if (request.readyState == 4) {// first, check that the request is finished
        // check that the request was successfull
        if (request.status == 200) {
            console.log('hey Mark. maybe you aren\'t so lazy afterall.');
            console.log(`${request.responseText}`);
            console.log(`${request.response}`);
            var jokeyjoke = JSON.parse(request.response);
            console.log(`${jokeyjoke.value.joke}`);
        }
    }
}



// open a connection to the site.
// specify the endpoint! (url/controller/action)
//          HttpMethod, full url to the endpoint,      async?
request.open('GET', 'http://api.icndb.com/jokes/random', true);


// send the request
request.send();


//NOW for a POST request
var request2 = new XMLHttpRequest();

request2.onreadystatechange = () => {
    console.log(`the readyState is => ${request2.readyState}`);
    if (request2.readyState == 4) {// first, check that the request is finished
        // check that the request was successfull
        if (request2.status >= 200 && request2.status < 300) {
            console.log('hey Mark. maybe you aren\'t so lazy afterall.');
            console.log(`${request2.responseText}`);
            console.log(`${request2.response}`);
            var player = JSON.parse(request2.response);
            console.log(`${player.street}, ${player.fname}, ${player.lname}`);
        }
        else {
            console.log('the request was not successful');
        }
    }
}

request2.open('POST', 'https://localhost:44335/api/RpsGame/CreateNewPlayer', true);

request2.setRequestHeader("Content-Type", "application/json");
//add other header here

//create the player to send in the body
var player = {
    fname: "Baby",
    lname: "Hewey",
    myCountry: "Disney",
    street: "123 Main",
    state: "cali-for-ah-aeeee",
    city: "Burbank",
    myAge: 100
}

request2.send(JSON.stringify(player));