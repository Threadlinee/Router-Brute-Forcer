# 🔐 Router Brute Forcer (C# WPF GUI)

A powerful C# WPF-based tool to perform brute-force attacks against routers and IoT devices using **HTTP Basic Authentication**. Designed with a clean XAML GUI and real-time logging, this tool is perfect for penetration testers, cybersecurity researchers, or home lab warriors.

---

## 🚀 Features

- ⚡ Brute-force HTTP Basic Auth on router login portals
- 🖥️ Clean, dark-themed WPF GUI
- 📄 Supports custom wordlists
- 🧠 Real-time logging of attempts
- ✅ Automatic success detection with popup alert

---

## 📸 Screenshots

![image](https://github.com/user-attachments/assets/579e25b4-3b1c-4f28-82a5-968127deda07)

---

## 🛠️ Requirements

- .NET Framework 4.7.2 or higher (or .NET 6+ if converted to SDK-style project)
- Visual Studio 2019/2022 or Rider

---

## 🧾 Usage

1. Clone or download the repository
2. Open the solution in Visual Studio
3. Build and run the project
4. Enter:
    - Target IP address (e.g., `192.168.1.1`)
    - Port number (default: `80`)
    - Username (e.g., `admin`)
    - Path to your `.txt` wordlist (1 password per line)
5. Click `Start Attack` and monitor the logs

---

## 📁 Example Wordlist Format

1234 admin admin123 root password

---

## ⚠️ Disclaimer

> This tool is intended **strictly for educational and authorized penetration testing purposes**.  
> Do **not** use it against any system without proper legal consent. The author is **not responsible** for any misuse or damage.

---

## ❤️ Credits

- Developed by dionabazi
- UI crafted with WPF & XAML
- Inspired by ethical hacking and security research

---

## 📦 Future Upgrades

- [ ] Add support for Form-Based login brute force
- [ ] Proxy support for anonymity
- [ ] Stop / Pause functionality
- [ ] Save successful attempts to a file
