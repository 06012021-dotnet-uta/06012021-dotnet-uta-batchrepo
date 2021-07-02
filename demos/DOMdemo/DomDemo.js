// const html = document.documentElement;
// console.log(html);

// const head = html.firstChild;
// console.log(head);
// const body = html.lastChild;
// console.log(body);

// const allChildren = body.parentElement.childNodes;
// console.log(allChildren);

// allChildren[1].nextElementSibling.bgColor = 'blue';

// allChildren[2].style.backgroundColor = 'green';

// const button = document.getElementsByTagName('button');
// console.log(button);



// const divEvent = document.getElementById('divId1');
// divEvent.addEventListener('click', e => {
//     //e.target.style.backgroundColor = 'grey';
//     divEvent.style.backgroundColor = 'green';
// });

// button[0].addEventListener('click', (event) => {
//     //you stop propagation to prevent the event form bubbling up 
//     // and triggering other event of hte same type in containing
//     // nodes.
//     event.stopPropagation;
//     //event.stopImmediatePropagation;
//     if (button[0].style.color == 'blue') {
//         button[0].style.color = 'red';
//     }
//     else {
//         button[0].style.color = 'blue'
//     }
//     console.log('the button was clicked');
//     console.log(event);
//     //event.toElement.outerText = 'DON\'T Click me';
// });

// get the one unordered list
const ul = document.getElementsByTagName('ul')[0];
console.log(ul);

//get the li's form that list
const lis = ul.childNodes;
console.log(lis);

for (li of lis) {
    li.addEventListener('click', e => {
        e.target.remove();
    });
}

const form = document.getElementsByTagName('form')[0];
form.addEventListener('submit', e => {
    e.preventDefault();
    value = form.todoIdea1.value;
    console.log(value);
    ul.innerHTML += `<li>${value}</li>`;
    form.todoIdea1.value = '';
    for (li of lis) {
        li.addEventListener('click', e => {
            e.target.remove();
        });
    }
});



