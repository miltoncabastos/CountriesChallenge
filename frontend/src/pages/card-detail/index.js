import { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import {
    Grid,
    CircularProgress,
    makeStyles,
    Snackbar,
    Slide
} from '@material-ui/core'
import CardCountryDetail from '../../components/card-country-detail'

const API_URL = 'https://localhost:5001/api';
const LOGIN = 'admin'
const PASSWORD = 'admin'

const FEEDBACK_DEFAULT = {
    open: false,
    message:''
}

const useStyle = makeStyles({
    root: {
        flexGrow: 1,
    },
});

export default function CardDetail() {
    const classes = useStyle();
    
    const [country, setCountry] = useState();
    const [feedback, setFeedback] = useState(FEEDBACK_DEFAULT);

    const { numericCode } = useParams();

    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    headers.set('Authorization', `Basic ${window.btoa(`${LOGIN}:${PASSWORD}`)}`);

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
        try {
            const response = await fetch(`${API_URL}/country/${numericCode}`, {
                method: 'get',          
                headers,
            });
            const data = await response.json();
            return data;
        } catch(err){
            return null
        }
    }    

    async function handleSave(country) {
        const model = {
            NumericCode: country.numericCode,
            
            Area: country.area,
            Population: country.population,
            PopulationDensity: country.populationDensity,
            Capital: country.capital,

            TopLevelDomains: country.topLevelDomains,
            Name: country.name,
        }

        try {
            const response = await fetch(`${API_URL}/country`, {
                method: 'POST',
                headers,
                body: JSON.stringify(model),
            })

            if(!response.ok)
            {
                handleOpenFeedback('Algum erro aconteceu')
                return;
            }

            handleOpenFeedback('Salvo com sucesso!');
        } catch(err) {
            return err;
        }
    }

    function handleOpenFeedback(message){
        setFeedback({
            open: true,
            message
        })
    }

    function handleCloseFeedback(){
        setFeedback(FEEDBACK_DEFAULT);
    }

    return (
        <Grid container className={classes.root}>
            <Grid item xs={12}>
                <Grid container justify="center">
                    {!country && <CircularProgress size={"5rem"} />}
                    {country && <CardCountryDetail country={country} handleSave={handleSave} />}
                    <Snackbar
                        open={feedback.open}
                        onClose={handleCloseFeedback}
                        message={feedback.message}
                        key={<Slide direction="Down"/>}
                        autoHideDuration={2000}
                    />
                </Grid>
            </Grid>
        </Grid>
    );
}