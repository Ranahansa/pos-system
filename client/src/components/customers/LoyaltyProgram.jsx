import React, { useState } from 'react';
import HomeButton from '../common/Button/HomeButton';
import SuccessAlert from '../common/Alert/SuccessAlert';

const Register = () => {
    const [showAlert, setShowAlert] = useState(false);

    const handleClick = (e) => {
        e.preventDefault();
        setShowAlert(true);
    };

    return (
        <div>
            <HomeButton onClick={handleClick} />
            {showAlert && <SuccessAlert />}
        </div>
    );
};

export default Register;