import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import {
    Grid,
    CircularProgress,
    makeStyles
} from '@material-ui/core'
import CardCountryDetail from '../../components/card-country-detail'

const { API_ENDPOINT } = process.env;

const useStyle = makeStyles({
    root: {
        flexGrow: 1,
    },
});

export default function CardDetail() {
    const classes = useStyle();
    const [country, setCountry] = useState();
    const { numericCode } = useParams();

    useEffect(() => {
        async function fetchData() {
            const countryBase = await getCountryBase();
            const countryUpdated = await getCountryUpdated();
            mountCountry(countryBase, countryUpdated)
        }

        fetchData();
    }, [])

    function mountCountry(countryBase, countryUpdated){
        if (countryUpdated) {
            setCountry({
                ...countryUpdated,
                flag: countryBase.flag.svgFile,
                populationDensity: countryBase.populationDensity,
            });
        } else {
            setCountry({
                ...countryBase,
                flag: countryBase.flag.svgFile,
                topLevelDomains: countryBase.topLevelDomains[0].name,
            });
        }
    }

    async function getCountryBase() {
        const filter = `(numericCode:"${numericCode}")`;

        const query = `
        query {
            Country${filter} {
                numericCode
                name
                capital
                area
                population
                populationDensity
                topLevelDomains {
                    name
                }
                flag {
                    svgFile
                }          
            }
        }`

        const result = await fetch('http://localhost:8080/', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                query: query
            })
        }).then(res => res.json());

        return result.data.Country[0];
    }

    async function getCountryUpdated() {
        const countryUpdated = await fetch(`${API_ENDPOINT}/country/${numericCode}`)
            .then(res => res.json())
            .catch(ex => console.log("no country updated"))

        return countryUpdated;
    }

    function handleSave(country) {
        const model = {
            NumericCode: country.numericCode,
            Name: country.name,
            Capital: country.capital,
            Area: country.area,
            Population: country.population,
            TopLevelDomains: country.topLevelDomains,
        }

        fetch(`${API_ENDPOINT}/country`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(model)
        })
    }

    return (
        <Grid container className={classes.root}>
            <Grid item xs={12}>
                <Grid container justify="center">
                    {!country && <CircularProgress size={"5rem"} />}
                    {country && <CardCountryDetail country={country} handleSave={handleSave} />}
                </Grid>
            </Grid>
        </Grid>
    );
}