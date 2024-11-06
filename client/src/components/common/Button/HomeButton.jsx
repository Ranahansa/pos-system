import React from 'react';
import { Button } from "@material-tailwind/react";

const HomeButton = ({ onClick }) => {
    return (
        <div>
            <Button onClick={onClick}>
                Button
            </Button>
        </div>
    );
}

export default HomeButton;