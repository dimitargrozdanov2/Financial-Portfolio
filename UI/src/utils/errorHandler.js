import { toast } from "react-toastify";

export function handleApiError(err, fallbackMessage = "An error occurred") {
  // Try to extract a nice message
  const message =
    err.response?.data?.message ||   // typical backend
    err.response?.data ||           // raw string
    err.message ||                  // axios error message
    fallbackMessage;

  toast.error(`❌ ${message}`);
}