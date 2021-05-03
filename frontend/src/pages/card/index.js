import { useState, useEffect } from 'react';
import { useSelector } from 'react-redux';

import CardCountry from '../../components/card-country/index';
import {
    Grid,
    CircularProgress,
    makeStyles,
    Typography
} from '@material-ui/core';

const useStyle = makeStyles({
    root: {
        flexGrow: 1,
    },
});

export default function Card() {
    const classes = useStyle();

    const [countries, setCountries] = useState([]);
    const [loading, setLoading] = useState(false);

    const search = useSelector(state => state.searchCountry);

    useEffect(() => {
        setLoading(true);
        const stringSearch = `(name:"${search}")`;

        const query = `
      query {
        Country${search && stringSearch} {
            numericCode
            name
            capital
            flag {
                svgFile
            }          
        }
      }
    `;

        fetch('http://localhost:8080/', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                query: query
            })
        }).then(res => res.json())
            .then(res => {
                setCountries(res.data.Country)
            })
            .then(() => setLoading(false));
    }, [search])

    return (
        <Grid container className={classes.root}>
            <Grid item xs={12}>
                <Grid container justify="center">
                    {
                        loading && <CircularProgress size={"5rem"} />
                    }
                    {
                        !loading && countries.length > 0 && 
                            countries.map((country, index) => {
                                return (
                                    <CardCountry key={index} country={country}></CardCountry>
                                )
                        })
                    }
                    {
                        !loading && !countries.length > 0 && 
                            <Typography>Nenhum registro encontrado</Typography>
                    }
                </Grid>
            </Grid>
        </Grid>
    );
}