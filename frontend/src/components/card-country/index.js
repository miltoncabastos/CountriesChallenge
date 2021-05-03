import {
    Card,
    CardContent,
    CardMedia,
    CardActions,
    makeStyles,
    Typography,
    Button,
} from '@material-ui/core'

import { Link } from 'react-router-dom';

const useStyle = makeStyles({
    root: {
        display: 'inline-block',
        width: 300,
        height: 350,
        margin: '5px',
        padding: '0px',
    },
    title: {
        marginTop: '10px',
    },
});


export default function CardCountry({ country }) {
    const classes = useStyle();

    return (
        <Card className={classes.root} bgcolor="text.disabled">
            <CardMedia
                component="svg"
                image={country.flag.svgFile}
            />
            <CardContent>
                <Typography gutterBottom variant="h5" component="h2" align="center">
                    {country.name}
                </Typography>
                <Typography className={classes.title} color="textSecondary">
                    Capital
                </Typography>
                <Typography variant="h6">{country.capital}</Typography>
            </CardContent>
            <CardActions>
                <Button component={Link} to={`/cardDetail/${country.numericCode}`} size="small">
                    View More
                </Button>
            </CardActions>
        </Card>
    )
}