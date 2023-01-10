variable "name" {
  description = "Name of the Resource Group"
  type        = string
}
variable "location" {
  description = "Azure location where resources should be deployed"
  default     = "eastasia"
  validation {
    condition     = contains(["southeastasia", "eastasia"], var.location) == true
    error_message = "Allowed Value : southeastasia,eastasia."
  }
}
