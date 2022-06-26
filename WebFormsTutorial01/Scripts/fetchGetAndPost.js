
async function FetchPost(url, obj) {

    let options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
            , 'Accept': 'application/json'
        }
        , body: JSON.stringify(obj)
    };

    const response = await fetch(url, options);
    const data = await response.json();
    console.log(data[0]);
    return data;
}

async function FetchGet(url) {
    const response = await fetch(url);
    const data = await response.json();
    console.log(data[0]);
    return data;
}