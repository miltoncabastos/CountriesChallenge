const { API_ENDPOINT } = process.env;

const methods = {
    get: 'GET',
    post: 'POST'
}

async function createFetch(path, method, body) {
    var response = fetch(`${API_ENDPOINT}/${path}`, {
        headers: { 'Content-Type': 'application/json' },
        method,
        body,
    }).then(res => res.json)
    .catch(ex => console.log(`error ${method} in ${path}: `, ex));

    return response;
}

const Request = () => {
    console.log("passou aqui")
    return {
        get: (path) => createFetch(path, methods.get),
        post: (path, body) => createFetch(path, methods.post, body),
    }
}

export default Request();