"use strict";
let R = null;

//TypeScript


let t1 = document.querySelector("#t1"); // local global

let b1 = document.querySelector("#b1");

let g1 = null;//table

async function loads()
{
    let url = `https://juxinglong.github.io/static/data/states.json`;

    let r =await fetch(url);
    let rj = await r.json();

    if (g1!=null)
    {
        g1.destroy();
    }
    t1.innerHTML = ``;

    let opts = {
        data: rj,
        width: 500,
        pagination: { limit: 5, },
        sort: true,
        search: true,
        columns: [{ id: "st", name: "State" }, {id:"p",name:"Population"}],
    };

    g1 = new gridjs.Grid(opts);
    g1.render(t1);

    R = rj;
    console.log(rj);

    //fetch(); //async
    //Swal.fire("Data loaded");
}

b1.addEventListener("click", loads);






