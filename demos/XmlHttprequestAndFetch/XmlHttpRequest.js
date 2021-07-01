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