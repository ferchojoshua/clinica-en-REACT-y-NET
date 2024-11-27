import { Route, Routes } from "react-router-dom";
import { Dashboard } from "../pages/Dashboard";

export default function SideRoutes() {
return (
    <Routes>
            <Route path="/" element={<Dashboard />} />
    </Routes>
)

}