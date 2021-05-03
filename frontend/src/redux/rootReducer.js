const initialState = {
    searchCountry: '',
}

export default function RootReducer(state = initialState, action) {
    switch (action.type) {
        case 'SEARCH_COUNTRY':
            return {
                ...state,
                searchCountry: action.searchCountry || "",
            };       
        default:
            return state;
    }
}