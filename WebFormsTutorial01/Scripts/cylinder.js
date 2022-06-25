//buttons
const btnCylXMLHttp = document.getElementById('btnCylXMLHttp');
const btnCylItemsFetch = document.getElementById('btnCylItemsFetch');
const btnCylItemsAxios = document.getElementById('btnCylItemsAxios');

//temp global variables
var globalUrl = "http://localhost:93"
// text area
const result = document.getElementById('result');
const itemsResult = document.getElementById('itemsResult');
const itemsAxiosResult = document.getElementById('itemsAxiosResult');

// add click event to btnCylinders
btnCylXMLHttp.addEventListener('click', (e) => {
    //var url = "http://localhost:93/Cylinders/Cylinder_getCylinderSize";
    var url = `${globalUrl}/Cylinders/WS_GetCylinderSize.asmx/Cylinder_GetCylinderSizes`

    var xhr = new XMLHttpRequest;
    xhr.open('GET', url, true);

    // If specified, responseType must be empty string or "document"
    xhr.responseType = 'document';

    // Force the response to be parsed as XML
    xhr.overrideMimeType('text/xml');

    xhr.onload = function () {
        if (xhr.readyState === xhr.DONE && xhr.status === 200) {
            console.log(xhr.response, xhr.responseXML);
        }
    };

    //xhr.send();

    // Creating a XHR object
    var xhr = new XMLHttpRequest();
    // open a connection
    xhr.open("POST", url, true);

    // Set the request header i.e. which type of content you are sending
    //xhr.setRequestHeader("Content-Type", "application/json");

    xhr.setRequestHeader("Content-Type", 'text/xml');
    xhr.responseType = "text";

    // Create a state change callback
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            let obj = this.responseText;
            console.log(obj);
            // Print received data from server
            result.innerHTML = obj;        
        }
    }
    // Sending data with the request
    xhr.send(null);
});

async function FetchTest() {
    var url = `${globalUrl}/Cylinders/WS_GetCylinderItems.asmx/Cylinder_getCylinderItems`; 

    var cylinderItem = {
        "cylinderItem":
        {
            "supItem": 'REF-PR114R150'
            , "itemMisId": 1056
        }
    };

    let options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
            , 'Accept': 'application/json'
        }
        , body: JSON.stringify(cylinderItem)
    };

    //const response = await fetch(url, options);
    const response = await fetch(url);
    const data = await response.json();
    console.log(data[0]);
    return data;
}

// add click event to btnCylinders
btnCylItemsFetch.addEventListener('click', (e) => {
    let items;
    FetchTest()
        .then(data => {
            console.log(data);
            data.forEach((curr, i, arr) => {
                console.log(`${curr.ItemMisId} ${curr.SupItem}`);
                items = `${curr.ItemMisId} ${curr.SupItem} <br> ${items}` ;
            });
            itemsResult.innerHTML = items;
        });
});

btnCylItemsAxios.addEventListener('click', (e) => {
    var url = `${globalUrl}/Cylinders/WS_GetCylinderItems.asmx/Cylinder_getCylinderItems`
    // Make a request for a user with a given ID
    axios.get(`${url}`)
        .then(function (response) {
            // handle success
            response.data.forEach((item) => {

                itemsAxiosResult.innerHTML = `${item.SupItem} ${item.ItemMisId} <br> ${itemsAxiosResult.innerHTML}`;
            })
            console.log(response);
        })
        .catch(function (error) {
            // handle error
            console.log(error);
        })
        .then(function () {
            // always executed
        });
})