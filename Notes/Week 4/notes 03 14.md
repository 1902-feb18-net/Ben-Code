# 03/14/2019

## Virtualization
- Singleboot: use of a single operating system on hardware
- Dualboot: use of two operating systems in a single piece of hardware
- Singleboot and Dualboot have no virtualization
- **Hypervisor**
    - Capable of hosting guest OS, and each of those can host apps
    - Hypervisors are hosted by host OS on a piece of hardware
    - Hypervisors do not necessarily include everything on the host OS, outside apps are permitted
    - This is OS level virtualization
        - Basically, the guest OS and any apps on them are virtual machines
    - Hypervisor is generally VirtualBox and VMWare
    - It's job is to pretend to be hardware so the guest OS doesn't need to know the difference.
        - Then it connects the guest OS to the actual OS
    - Run one version of an app on one virtual machine, avoid file conflicts
    - When the user starts a virtual machine they must allocate fixed block of RAM
- **Container**
    - Next level of virtualization
    - Contains dependencies like NuGet and .NET Core runtime packages to help run apps that are contained in the container
    - Need dependencies in one place, then all apps can use it.
    - Used when a separate operating system is not necessary, because that involves a large amount of overhead.
    - It pretends that a single application is the only thing running on the same system, when in actuality many instances can be
    - Containers flexibly use resources like memory in the same way as regular OS processes.
    - More granularity than virtual machines when creating many instances of an app