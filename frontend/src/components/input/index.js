import { TextField } from "@material-ui/core";


export default function Input(props) {
    return (
        <TextField
            fullWidth
            variant="outlined"
            {...props}
        />
    )
}