import { Alert } from "@material-tailwind/react";

function ErrorIcon() {
    return (
        <svg
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 24 24"
            fill="currentColor"
            className="w-6 h-6"
        >
            <path
                fillRule="evenodd"
                d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm10.03-2.47a.75.75 0 00-1.06 0L12 10.69l-1.22-1.22a.75.75 0 10-1.06 1.06L10.94 12l-1.22 1.22a.75.75 0 101.06 1.06L12 13.31l1.22 1.22a.75.75 0 101.06-1.06L13.06 12l1.22-1.22a.75.75 0 000-1.06z"
                clipRule="evenodd"
            />
        </svg>
    );
}

const ErrorAlert = () => {
    return (
        <Alert
            icon={<ErrorIcon />}
            className="rounded-none border-l-4 border-[#f44336] bg-[#f44336]/10 font-medium text-[#f44336]"
        >
            An error has occurred.
        </Alert>
    );
}

export default ErrorAlert;