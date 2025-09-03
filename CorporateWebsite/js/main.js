/**
* Template Name: Veritas Law
* Updated: Sep 01 2024 with Bootstrap v5.3.3
* Author: Cascade AI
* License: https://opensource.org/licenses/MIT
*/
document.addEventListener('DOMContentLoaded', () => {
  "use strict";

  /**
   * Dark Mode Toggle
   */
  const themeToggle = document.getElementById('theme-toggle');
  const htmlEl = document.documentElement;

  // Function to set theme and icon
  const setTheme = (theme) => {
    htmlEl.setAttribute('data-bs-theme', theme);
    if (themeToggle) {
        const icon = themeToggle.querySelector('i');
        if (theme === 'dark') {
        icon.classList.remove('fa-moon');
        icon.classList.add('fa-sun');
        } else {
        icon.classList.remove('fa-sun');
        icon.classList.add('fa-moon');
        }
    }
    localStorage.setItem('theme', theme);
  };

  // Check for saved theme in localStorage or system preference
  const savedTheme = localStorage.getItem('theme');
  const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;

  if (savedTheme) {
    setTheme(savedTheme);
  } else {
    setTheme(prefersDark ? 'dark' : 'light');
  }

  // Event listener for the toggle button
  if (themeToggle) {
    themeToggle.addEventListener('click', () => {
        const currentTheme = htmlEl.getAttribute('data-bs-theme');
        setTheme(currentTheme === 'dark' ? 'light' : 'dark');
    });
  }

  /**
   * Smooth Scroll for anchor links
   */
  document.querySelectorAll('a.nav-link[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
      e.preventDefault();
      const targetId = this.getAttribute('href');
      const targetElement = document.querySelector(targetId);
      if (targetElement) {
        targetElement.scrollIntoView({ behavior: 'smooth' });
      }
    });
  });

  /**
   * Animation on scroll logic
   */
  const sections = document.querySelectorAll('[data-aos]');
  if (sections.length > 0) {
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
        if (entry.isIntersecting) {
            // Add a class to trigger the animation
            entry.target.classList.add('aos-animate'); 
            observer.unobserve(entry.target);
        }
        });
    }, { threshold: 0.1 });

    sections.forEach(section => {
        // Set initial state for animation
        section.style.opacity = '0';
        section.style.transform = 'translateY(20px)';
        section.style.transition = 'opacity 0.6s ease-out, transform 0.6s ease-out';
        observer.observe(section);
    });

    // Add CSS for the animation class
    const style = document.createElement('style');
    style.innerHTML = `
        .aos-animate {
            opacity: 1 !important;
            transform: translateY(0) !important;
        }
    `;
    document.head.appendChild(style);
  }

});
